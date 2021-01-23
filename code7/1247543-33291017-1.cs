    public JsonResult SendEmailItemsToClient(int proyecto, string[] items, string observation) 
        {
            object data = null;
            try
            {
                foreach (var item in items) 
                {
                    string test = item.ToString();
                }
                string mensaje = "";
                int ProjectIdx = proyecto;
                bool resp = CorreccionesController.SendItemsDifferentsToClient(ProjectIdx, mensaje);
                if (resp) { 
                    data = new
                    {
                        success = true,
                        titulo = "Notification",
                        mensaje = "A message explaining why the different items selected are used had been sent"
                    };
                } 
                else 
                {
                    data = new
                    {
                        success = false,
                        titulo = "Notification",
                        mensaje = "The observation is Saved but the email couldn't be send, please contact support"
                    };
                }
            }
            catch (Exception ex) 
            {
                data = new
                {
                    success = false,
                    titulo = "ERROR",
                    mensaje = ex.ToString()
                };
            }
            return Json(data, JsonRequestBehavior.AllowGet);
        }
