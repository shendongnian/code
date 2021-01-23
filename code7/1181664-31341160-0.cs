     TableCell celluleBouton = new TableCell();
     System.Web.UI.WebControls.Button boutonLire = new System.Web.UI.WebControls.Button();
      boutonLire.Text = "Telecharger";
      boutonLire.ID = svgID.ToString();
      boutonLire.Attributes.Add("onclick", "return clicArticle(this);");
      // on le crée graphiquement
      celluleBouton.Controls.Add(boutonLire);
      tableColonne.Cells.Add(celluleBouton);
      tableau.Rows.Add(tableColonne);
