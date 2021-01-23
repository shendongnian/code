    class FormFornitore: Form
    {
       protected FormPrincipale parent;
       FormFornitore(FormPrincipale parent)
       {
          this.parent = parent;
       }
        private void gridFornitori_DoubleClick(object sender, EventArgs e)
        {
          try
          {
            var Codice = gridView2.GetFocusedDataRow()["codconto"].ToString();
            var RagSoc = gridView2.GetFocusedDataRow()["dscconto1"].ToString();
            /// REMOVE THIS FormPrincipale Form = new FormPrincipale();
            parent.getFornitore(Codice, RagSoc);
            this.Close();
          }
          catch(Exception excGrid)
          {
            MessageBox.Show("GRID: " + excGrid.Message);
          }
        }
    }
