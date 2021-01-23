    using DevExpress.XtraGrid.Views.Grid;
    using DevExpress.XtraGrid.Columns;
    using DevExpress.Utils;
    
    private void Form1_Load(object sender, System.EventArgs e) {
       // ... 
       InitStyles();
    }
    
    private void InitStyles() {
       GridView View = gridControl1.MainView as GridView;
       // Customize the column headers' appearances. 
       AppearanceObject appCountry = View.Columns["Country"].AppearanceHeader;
       appCountry.BackColor = Color.AntiqueWhite;
       appCountry.BackColor2 = Color.Snow;
       View.Columns["City"].AppearanceHeader.BackColor = Color.LightSalmon;
       // Set the View's painting syle. 
       View.PaintStyleName = "UltraFlat";
    }
