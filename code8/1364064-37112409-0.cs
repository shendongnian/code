    public override object BindModel(ControllerContext controllerContext, ModelBindingContext bindingContext)
        {
            SearchVM result = (SearchVM)base.BindModel(controllerContext, bindingContext);
            try
            {
                if (result != null)
                {
                    if (result.NullableDate != null)
                    {                                      
                        result.NullableDate = DateTime.ParseExact(result.NullableDate.ToString(), "MM'/'dd'/'yyyy H:mm:ss", new CultureInfo("es-ES"));
                    }
                }
            }
            catch(Exception e)
            {
                NLog.LogManager.GetCurrentClassLogger().Error("Error al hacer el Bind específico de SearchVM. ", e);
            }
            return result;
        }
