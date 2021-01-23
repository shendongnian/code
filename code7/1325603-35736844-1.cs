        [HttpPut]
                [Route("DeleteFile")]
                public JObject DeleteFile(int cabinetFileID)
                {
                    var fileName = cabinetDataAccess.GetFilePath(cabinetFileID);                  
                        var returnVal = cabinetDataAccess.DeleteCabinetFile(cabinetFileID, UserEmail);
     var jsonString = Json(new JavaScriptSerializer().Serialize(new { returnVal }));
                    return JObject.Parse(jsonString.Content);      
                }
