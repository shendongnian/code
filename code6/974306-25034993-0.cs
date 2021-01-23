        settings.Columns.Add(c =>
        {
            c.SetDataItemTemplateContent(a =>
            {
                ViewContext.Writer.Write(
                       "<a href='/Terceiros/carregarTerceiroAlerta?idForn=" + DataBinder.Eval(a.DataItem, "IdForn") + "&idFilialForn=" + DataBinder.Eval(a.DataItem, "IdFilialForn") + "'target = \"_blank\">Ir para ...</a>");
            });
            c.Width = System.Web.UI.WebControls.Unit.Percentage(7);
        });
