    public static JsonResult ToPascalCase(this Controller controller, object model)
            {
                return controller.Json(model, new JsonSerializerSettings
                {
                    ContractResolver = new DefaultContractResolver()
                });
            }
