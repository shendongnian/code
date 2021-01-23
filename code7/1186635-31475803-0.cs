    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Data.SqlClient;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Windows.Forms;
    using System.Reflection;
    
    
    namespace DGVirtualScroll
    {
        public partial class Form1 : Form
        {
            private string connectionString =
            "Initial Catalog=Test1;Data Source=BBATRIDIP\\SQLSERVER2008R2;" +
            "Integrated Security=SSPI;Persist Security Info=False";
            private string table = "Orders";
    
            int Page_Size = 16;
            private string strPrevSortCol = "";
            private string strSortCol = "OrderID";
            private string strSortOrder = "ASC";
    
            private Cache memoryCache=null;
    
            public Form1()
            {
                InitializeComponent();
    
                // use DoubleBuffered to remove flicker when user load frequently clicking on load button
                typeof(DataGridView).InvokeMember("DoubleBuffered",
                    BindingFlags.NonPublic | BindingFlags.Instance | BindingFlags.SetProperty,
                    null,
                    this.dataGridView1,
                    new object[] { true });
    
                this.dataGridView1.VirtualMode = true;
                this.dataGridView1.ReadOnly = true;
                this.dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
                this.dataGridView1.CellValueNeeded += new DataGridViewCellValueEventHandler(dataGridView1_CellValueNeeded);
            }
    
            private void dataGridView1_CellValueNeeded(object sender,DataGridViewCellValueEventArgs e)
            {
                e.Value = memoryCache.RetrieveElement(e.RowIndex, e.ColumnIndex);
            }
    
            private void btnLoad_Click(object sender, EventArgs e)
            {
                Resetsort();
                LoadData(strSortCol, strSortOrder);
            }
    
            private void Resetsort()
            {
                strPrevSortCol = "OrderID";
                strSortCol = "OrderID";
                strSortOrder = "ASC";
            }
    
            private void LoadData(string strSortCol, string strSortOrder)
            {
    
                dataGridView1.Rows.Clear();
                dataGridView1.Refresh();
                dataGridView1.Columns.Clear();
                dataGridView1.DataSource = null;
    
                try
                {
                    DataRetriever retriever = new DataRetriever(connectionString, table, strSortCol + " " + strSortOrder);
                    memoryCache = new Cache(retriever, Page_Size);
                    //foreach (DataColumn column in retriever.Columns)
                    //{
                    //    dataGridView1.Columns.Add(column.ColumnName, column.ColumnName);
                    //}
    
                    retriever.Columns.Cast<DataColumn>().ToList().ForEach(n => dataGridView1.Columns.Add(n.ColumnName, n.ColumnName));
                    this.dataGridView1.RowCount = retriever.RowCount;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Connection could not be established. " + "Verify that the connection string is valid.");
                    Application.Exit();
                }
    
                // Adjust the column widths based on the displayed values. 
                this.dataGridView1.AutoResizeColumns(DataGridViewAutoSizeColumnsMode.DisplayedCells);
    
                if (strSortOrder == "ASC")
                    this.dataGridView1.Columns[strSortCol].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;
                else
                    this.dataGridView1.Columns[strSortCol].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Descending;
    
            }
    
            private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
            {
                // this routine will add row no to HeaderCell which comes left most
                var grid = sender as DataGridView;
                var rowIdx = (e.RowIndex + 1).ToString();
    
                var centerFormat = new StringFormat()
                {
                    // right alignment might actually make more sense for numbers
                    Alignment = StringAlignment.Center,
                    LineAlignment = StringAlignment.Center
                };
    
                var headerBounds = new Rectangle(e.RowBounds.Left, e.RowBounds.Top, grid.RowHeadersWidth, e.RowBounds.Height);
                e.Graphics.DrawString(rowIdx, this.Font, SystemBrushes.ControlText, headerBounds, centerFormat);
            }
    
            private void dataGridView1_ColumnHeaderMouseClick(object sender, DataGridViewCellMouseEventArgs e)
            {
                string strSortCol = this.dataGridView1.Columns[e.ColumnIndex].Name;
    
                if (strPrevSortCol.Trim().ToUpper() != strSortCol.Trim().ToUpper())
                {
                    this.dataGridView1.Columns[strPrevSortCol].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.None;
                    strPrevSortCol = strSortCol;
                    strSortOrder = "ASC";
                }
    
                if (this.dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == System.Windows.Forms.SortOrder.Ascending)
                {
                    this.dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Descending;
                    strSortOrder = "DESC";
                }
                else if (this.dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection == System.Windows.Forms.SortOrder.Descending)
                {
                    this.dataGridView1.Columns[e.ColumnIndex].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;
                    strSortOrder = "ASC";
                }
                else
                {
                    if (strSortOrder == "ASC")
                        this.dataGridView1.Columns[strSortCol].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Ascending;
                    else
                        this.dataGridView1.Columns[strSortCol].HeaderCell.SortGlyphDirection = System.Windows.Forms.SortOrder.Descending;
    
                }
    
                dataGridView1.Rows.Clear();
    
                DataRetriever retriever = new DataRetriever(connectionString, table, strSortCol + " " + strSortOrder);
                memoryCache = new Cache(retriever, Page_Size);
                this.dataGridView1.RowCount = retriever.RowCount;
                dataGridView1.Refresh();
            }
    
    
        }
    }
    
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace DGVirtualScroll
    {
        public interface IDataPageRetriever
        {
            DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage);
        }
    
        public class DataRetriever : IDataPageRetriever
        {
            private string tableName;
            private SqlCommand command;
            private string sortColumn;
    
            public DataRetriever(string connectionString, string tableName, string sortColumn)
            {
                SqlConnection connection = new SqlConnection(connectionString);
                connection.Open();
                command = connection.CreateCommand();
                this.tableName = tableName;
                this.sortColumn = sortColumn;
            }
    
            private int rowCountValue = -1;
    
            public int RowCount
            {
                get
                {
                    // Return the existing value if it has already been determined. 
                    if (rowCountValue != -1)
                    {
                        return rowCountValue;
                    }
    
                    // Retrieve the row count from the database.
                    command.CommandText = "SELECT COUNT(*) FROM " + tableName;
                    rowCountValue = (int)command.ExecuteScalar();
                    return rowCountValue;
                }
            }
    
            private DataColumnCollection columnsValue;
    
            public DataColumnCollection Columns
            {
                get
                {
                    // Return the existing value if it has already been determined. 
                    if (columnsValue != null)
                    {
                        return columnsValue;
                    }
    
                    // Retrieve the column information from the database.
                    command.CommandText = "SELECT * FROM " + tableName;
                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = command;
                    DataTable table = new DataTable();
                    table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                    adapter.FillSchema(table, SchemaType.Source);
                    columnsValue = table.Columns;
                    return columnsValue;
                }
            }
    
            private string commaSeparatedListOfColumnNamesValue = null;
    
            private string CommaSeparatedListOfColumnNames
            {
                get
                {
                    // Return the existing value if it has already been determined. 
                    if (commaSeparatedListOfColumnNamesValue != null)
                    {
                        return commaSeparatedListOfColumnNamesValue;
                    }
    
                    // Store a list of column names for use in the 
                    // SupplyPageOfData method.
                    System.Text.StringBuilder commaSeparatedColumnNames =
                        new System.Text.StringBuilder();
                    bool firstColumn = true;
                    foreach (DataColumn column in Columns)
                    {
                        if (!firstColumn)
                        {
                            commaSeparatedColumnNames.Append(", ");
                        }
                        commaSeparatedColumnNames.Append(column.ColumnName);
                        firstColumn = false;
                    }
    
                    commaSeparatedListOfColumnNamesValue =
                        commaSeparatedColumnNames.ToString();
                    return commaSeparatedListOfColumnNamesValue;
                }
            }
    
            // Declare variables to be reused by the SupplyPageOfData method. 
            private string columnToSortBy;
            private SqlDataAdapter adapter = new SqlDataAdapter();
    
            public DataTable SupplyPageOfData(int lowerPageBoundary, int rowsPerPage)
            {
                // Store the name of the ID column. This column must contain unique  
                // values so the SQL below will work properly. 
                if (columnToSortBy == null)
                {
                    columnToSortBy = this.Columns[0].ColumnName;
                }
    
                if (!this.Columns[columnToSortBy].Unique)
                {
                    throw new InvalidOperationException(String.Format(
                        "Column {0} must contain unique values.", columnToSortBy));
                }
    
                // Retrieve the specified number of rows from the database, starting 
                // with the row specified by the lowerPageBoundary parameter.
                command.CommandText = "Select Top " + rowsPerPage + " " +
                    CommaSeparatedListOfColumnNames + " From " + tableName +
                    " WHERE " + columnToSortBy + " NOT IN (SELECT TOP " +
                    lowerPageBoundary + " " + columnToSortBy + " From " +
                    tableName + " Order By " + sortColumn + 
                    ") Order By " + sortColumn ;
                adapter.SelectCommand = command;
    
                DataTable table = new DataTable();
                table.Locale = System.Globalization.CultureInfo.InvariantCulture;
                adapter.Fill(table);
                return table;
            }
    
        }
    }
    
    
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Data;
    using System.Data.SqlClient;
    
    namespace DGVirtualScroll
    {
        public class Cache
        {
            private static int RowsPerPage;
    
            // Represents one page of data.   
            public struct DataPage
            {
                public DataTable table;
                private int lowestIndexValue;
                private int highestIndexValue;
    
                public DataPage(DataTable table, int rowIndex)
                {
                    this.table = table;
                    lowestIndexValue = MapToLowerBoundary(rowIndex);
                    highestIndexValue = MapToUpperBoundary(rowIndex);
                    System.Diagnostics.Debug.Assert(lowestIndexValue >= 0);
                    System.Diagnostics.Debug.Assert(highestIndexValue >= 0);
                }
    
                public int LowestIndex
                {
                    get
                    {
                        return lowestIndexValue;
                    }
                }
    
                public int HighestIndex
                {
                    get
                    {
                        return highestIndexValue;
                    }
                }
    
                public static int MapToLowerBoundary(int rowIndex)
                {
                    // Return the lowest index of a page containing the given index. 
                    return (rowIndex / RowsPerPage) * RowsPerPage;
                }
    
                private static int MapToUpperBoundary(int rowIndex)
                {
                    // Return the highest index of a page containing the given index. 
                    return MapToLowerBoundary(rowIndex) + RowsPerPage - 1;
                }
            }
    
            private DataPage[] cachePages;
            private IDataPageRetriever dataSupply;
    
            public Cache(IDataPageRetriever dataSupplier, int rowsPerPage)
            {
                dataSupply = dataSupplier;
                Cache.RowsPerPage = rowsPerPage;
                LoadFirstTwoPages();
            }
    
            // Sets the value of the element parameter if the value is in the cache. 
            private bool IfPageCached_ThenSetElement(int rowIndex,
                int columnIndex, ref string element)
            {
                if (IsRowCachedInPage(0, rowIndex))
                {
                    element = cachePages[0].table
                        .Rows[rowIndex % RowsPerPage][columnIndex].ToString();
                    return true;
                }
                else if (IsRowCachedInPage(1, rowIndex))
                {
                    element = cachePages[1].table
                        .Rows[rowIndex % RowsPerPage][columnIndex].ToString();
                    return true;
                }
    
                return false;
            }
    
            public string RetrieveElement(int rowIndex, int columnIndex)
            {
                string element = null;
    
                if (IfPageCached_ThenSetElement(rowIndex, columnIndex, ref element))
                {
                    return element;
                }
                else
                {
                    return RetrieveData_CacheIt_ThenReturnElement(
                        rowIndex, columnIndex);
                }
            }
    
            private void LoadFirstTwoPages()
            {
                cachePages = new DataPage[]
                {
                    new DataPage(dataSupply.SupplyPageOfData(DataPage.MapToLowerBoundary(0), RowsPerPage), 0), 
                    new DataPage(dataSupply.SupplyPageOfData(DataPage.MapToLowerBoundary(RowsPerPage), RowsPerPage), RowsPerPage)
                };
            }
    
            private string RetrieveData_CacheIt_ThenReturnElement(int rowIndex, int columnIndex)
            {
                // Retrieve a page worth of data containing the requested value.
                DataTable table = dataSupply.SupplyPageOfData(
                    DataPage.MapToLowerBoundary(rowIndex), RowsPerPage);
    
                // Replace the cached page furthest from the requested cell 
                // with a new page containing the newly retrieved data.
                cachePages[GetIndexToUnusedPage(rowIndex)] = new DataPage(table, rowIndex);
    
                return RetrieveElement(rowIndex, columnIndex);
            }
    
            // Returns the index of the cached page most distant from the given index 
            // and therefore least likely to be reused. 
            private int GetIndexToUnusedPage(int rowIndex)
            {
                if (rowIndex > cachePages[0].HighestIndex &&
                    rowIndex > cachePages[1].HighestIndex)
                {
                    int offsetFromPage0 = rowIndex - cachePages[0].HighestIndex;
                    int offsetFromPage1 = rowIndex - cachePages[1].HighestIndex;
                    if (offsetFromPage0 < offsetFromPage1)
                    {
                        return 1;
                    }
                    return 0;
                }
                else
                {
                    int offsetFromPage0 = cachePages[0].LowestIndex - rowIndex;
                    int offsetFromPage1 = cachePages[1].LowestIndex - rowIndex;
                    if (offsetFromPage0 < offsetFromPage1)
                    {
                        return 1;
                    }
                    return 0;
                }
    
            }
    
            // Returns a value indicating whether the given row index is contained 
            // in the given DataPage.  
            private bool IsRowCachedInPage(int pageNumber, int rowIndex)
            {
                return rowIndex <= cachePages[pageNumber].HighestIndex &&
                    rowIndex >= cachePages[pageNumber].LowestIndex;
            }
    
        }
    }
