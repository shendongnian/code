    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Data;
    using System.Drawing;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    namespace Plan_de_lucru_1._0
    {
        public partial class SearchWindow : Form
        {
            public frPlanMain refTofrPlanMain;
            public SearchWindow(frPlanMain f) //<<Edit made here 
            {
                refTofrPlanMain = f;
                InitializeComponent();
            }
            private void SearchButtonW_Click(object sender, EventArgs e)
            {
                (refTofrPlanMain.dGVPlan.DataSource as DataTable).DefaultView.RowFilter = string.Format("Vodic = '{0}'", searchTBoxW.Text);
                for (int i = refTofrPlanMain.dGVPlan.Rows.Count - 1; i >= 0; i--)
                {
                    DataGridViewRow item = refTofrPlanMain.dGVPlan.Rows[i];
                    if (item.Visible)
                    {
                        refTofrPlanMain.dGVPlan.Rows.RemoveAt(i);
                        break;                      
                    }
                }
            }
            private void clearFilter_onClick(object sender, EventArgs e){
                (refTofrPlanMain.dGVPlan.DataSource as DataTable).DefaultView.RowFilter = null;            
            }
        }
    }
