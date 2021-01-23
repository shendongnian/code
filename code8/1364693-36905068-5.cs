    using System.Data;
    using System.Windows;
    using System.Windows.Controls;
    using System.Windows.Media;
    
    
    namespace testscroll
    {
        /// <summary>
        /// Interaction logic for MainWindow.xaml
        /// </summary>
        public partial class MainWindow : Window
        {
            public MainWindow()
            {
                InitializeComponent();
                panel.Children.Clear();
    
    
                Label lblTicket = new Label();
                lblTicket.Content = "RT Ticket";
                panel.Children.Add(lblTicket);
                TextBox txtBoxRTTicket = new TextBox();
    
                txtBoxRTTicket.Text = "test";
                txtBoxRTTicket.MaxLength = 5;
                txtBoxRTTicket.Margin = new Thickness(60, -25, 0, 0);
                panel.Children.Add(txtBoxRTTicket);
    
                TextBox txtBoxRTTicketFull = new TextBox();
                txtBoxRTTicketFull.Foreground = Brushes.Blue;
                txtBoxRTTicketFull.TextDecorations = TextDecorations.Underline;
                txtBoxRTTicketFull.Name = "txtBoxRTTicketFull";
                txtBoxRTTicketFull.Text = "http://mtl-ppapp-rt01/rt/Ticket/Display.html?id=" + "11111";
                //txtBoxRTTicket.TextChanged += TxtBoxRTTicket_TextChanged;
                //txtBoxRTTicketFull.MouseDoubleClick += TextBox_MouseDoubleClick;
                txtBoxRTTicketFull.IsReadOnly = true;
                txtBoxRTTicketFull.Margin = new Thickness(200, -25, 0, 0);
                panel.Children.Add(txtBoxRTTicketFull);
    
                Label space1 = new Label();
                space1.Content = "";
                panel.Children.Add(space1);
                Label lblTrackPage = new Label();
                lblTrackPage.Content = "Trac Page";
                panel.Children.Add(lblTrackPage);
                TextBox txtBoxTrackPage = new TextBox();
                txtBoxTrackPage.Text = "test";
                txtBoxTrackPage.Foreground = Brushes.Blue;
                txtBoxTrackPage.TextDecorations = TextDecorations.Underline;
                //txtBoxTrackPage.MouseDoubleClick += TextBox_MouseDoubleClick;
                txtBoxTrackPage.Margin = new Thickness(60, -25, 0, 0);
                panel.Children.Add(txtBoxTrackPage);
                //un espace dans le stackpanel
                Label space2 = new Label();
                space2.Content = "";
                panel.Children.Add(space2);
                //on ajoute le premier tableau concernant le pcb
                DataTable tablePCB = new DataTable();
                tablePCB.Columns.Add("PCB Number");
                tablePCB.Columns.Add("CAD Number");
                tablePCB.Columns.Add("Baan Descriptiion");
                tablePCB.Columns.Add("Display Description");
                tablePCB.Columns.Add("Detail Description");
                tablePCB.Rows.Add();
                tablePCB.Rows[0][0] = "000-00000-00";
                string cadNbr = ((string)tablePCB.Rows[0][0]).Substring(3, 6);
                tablePCB.Rows[0][1] = "cad" + cadNbr;
                tablePCB.Rows[0][2] = "test";
                tablePCB.Rows[0][3] = "test";
                tablePCB.Rows[0][4] = "test";
                tablePCB.Columns[0].ReadOnly = true;
                tablePCB.Columns[1].ReadOnly = true;
                tablePCB.Columns[2].ReadOnly = true;
                tablePCB.Columns[3].ReadOnly = true;
                DataGrid dgvPCB = new DataGrid();
                
                dgvPCB.CanUserAddRows = false;
                dgvPCB.ItemsSource = tablePCB.DefaultView;
                
                panel.Children.Add(dgvPCB);
                //un espace dans le stackpanel
                Label space3 = new Label();
                space3.Content = "";
                panel.Children.Add(space3);
                //on ajoute le premier tableau concernant les assembly
                DataTable tableAssy = new DataTable();
                tableAssy.Columns.Add("Assembly Number");
                tableAssy.Columns.Add("Schematic Description");
                tableAssy.Columns.Add("Work Instruction");
                tableAssy.Columns.Add("Warehouse");
                tableAssy.Columns.Add("Baan Description");//isreadonly
                tableAssy.Columns.Add("Display Description");
                tableAssy.Columns.Add("Detail Description");
                for (int i = 0; i < 1; i++)
                {
                    tableAssy.Rows.Add();
                    tableAssy.Rows[i][0] = "test";
                    tableAssy.Rows[i][1] = "test";
                    tableAssy.Rows[i][2] = "test";
                    tableAssy.Rows[i][3] = "test";
                    tableAssy.Rows[i][4] = "test";
                    tableAssy.Rows[i][5] = "test";
                    tableAssy.Rows[i][6] = "test";
                }
                tableAssy.Columns[3].ReadOnly = true;
                tableAssy.Columns[4].ReadOnly = true;
                DataGrid dgvAssy = new DataGrid();
                dgvPCB.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
                dgvAssy.VerticalScrollBarVisibility = ScrollBarVisibility.Disabled;
    
                dgvAssy.PreviewMouseWheel += DgvAssy_PreviewMouseWheel;
                dgvPCB.PreviewMouseWheel += DgvAssy_PreviewMouseWheel;
                //dgvAssy.CanUserAddRows = false;
                dgvAssy.ItemsSource = tableAssy.DefaultView;
    
                panel.Children.Add(dgvAssy);
    
                if (null != panel.FindName(txtBoxRTTicketFull.Name))
                    panel.UnregisterName(txtBoxRTTicketFull.Name);
                panel.RegisterName(txtBoxRTTicketFull.Name, txtBoxRTTicketFull);
    
                Label lblNote = new Label();
                lblNote.Content = "Notes:";
    
                TextBox txtBoxNotes = new TextBox();
                txtBoxNotes.Text = "test";
                txtBoxNotes.AcceptsReturn = true;
                txtBoxNotes.Height = 300;
                txtBoxNotes.VerticalScrollBarVisibility = ScrollBarVisibility.Auto;
                txtBoxNotes.MaxHeight = 300;
                txtBoxNotes.TextWrapping = TextWrapping.Wrap;
                txtBoxNotes.MaxWidth = 800;
                txtBoxNotes.ScrollToEnd();
                Button btnAddAssembly = new Button();
                btnAddAssembly.Content = "Save changes";
                //btnAddAssembly.Click += ((sender1, e1) => save_click(sender1, e1, txtBoxRTTicket.Text, txtBoxTrackPage.Text, (string)tablePCB.Rows[0][3], (string)tablePCB.Rows[0][4], tableAssy, txtBoxNotes, log));
                panel.Children.Add(btnAddAssembly);
    
                panel.Children.Add(lblNote);
    
                panel.Children.Add(txtBoxNotes);
    
            }
    
            private void DgvAssy_PreviewMouseWheel(object sender, System.Windows.Input.MouseWheelEventArgs e)
            {
                scrollviewer1.ScrollToVerticalOffset(scrollviewer1.VerticalOffset - e.Delta);
            }
        }
    }
