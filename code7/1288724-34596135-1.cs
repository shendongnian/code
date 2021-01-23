    //Code
     protected void grvResultados_CustomColumnDisplayText(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewColumnDisplayTextEventArgs e)
        {
            if (e.Column.FieldName.Contains("FECHA"))
            {
                if (!String.IsNullOrEmpty(e.Value.ToString()))
                {
                    try
                    {
                        e.DisplayText = ((DateTime)e.Value).ToString("dd/MM/yyyy HH:mm:ss");
                    }
                    catch
                    {
                        e.DisplayText = e.Value.ToString();
                    }
                }
                e.Column.UnboundType = DevExpress.Data.UnboundColumnType.DateTime;
            }
        }
     protected void grvResultados_BeforeColumnSortingGrouping(object sender, DevExpress.Web.ASPxGridView.ASPxGridViewBeforeColumnGroupingSortingEventArgs e)
        {
            try
            {
                MuestraResultados(0);
            }
            catch (Exception ex)
            {
                mpPage.MuestraPopUp(GenerarError(this.Page.ToString(), ex.Message, ex.StackTrace.ToString()), "ERROR");
            }
        }
    
        protected void grvResultados_PageIndexChanged(object sender, EventArgs e)
        {
            try
            {
                MuestraResultados(grvResultados.PageIndex);
            }
            catch (Exception ex)
            {
                mpPage.MuestraPopUp(GenerarError(this.Page.ToString(), ex.Message, ex.StackTrace.ToString()), "ERROR");
            }
        }
