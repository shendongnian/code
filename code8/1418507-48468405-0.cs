    public ActionResult DeleteSelected([FromBody]List<string> ids)
        {
            try
            {
                if (ids != null && ids.Count > 0)
                {
                    foreach (var id in ids)
                    {
                        bool done = new tblCodesVM().Delete(Convert.ToInt32(id));
                        
                    }
                    return Json(new { success = true, responseText = "Deleted Scussefully" });
                }
                return Json(new { success = false, responseText = "Nothing Selected" });
            }
            catch (Exception dex)
            {
                
                return Json(new { success = false, responseText = dex.Message });
            }
        }
