        try
            {
                String ltq_str = new JavaScriptSerializer().Serialize(ltq);
                int t = -1;
                String result = Gnuse.HTTPSend("http://localhost/is/TQueueDtcs/integrationservice?tQueueDtcslist=", HttpUtility.UrlEncode(ltq_str), ref t, "GET");
                if (!result.Equals("success"))
                {
                    GRN.delete(Convert.ToInt32(hfId.Value), false);
                    lblError.Text = "Inventory integration failed: " + result;
                }
            }
            catch (Exception e)
            {
                e.Message.ToString();
            }
