     [HttpPost]
                public JsonResult GetStudentList(Int32 lectureid)
                {
                    try
                    {
                        object allrecord = _IAcademy_Repository.GetStudentRecordAccordingAttendanceWise(lectureid);
                        return Json(new
                        {
                            allrecord = allrecord
                        }, JsonRequestBehavior.AllowGet);
                    }
                    catch (Exception ex)
                    {
                        ErrorLogger.ErrorLog(ex);
                        return Json(new
                        {
                            allrecord = new List<string[]> { }
                        }, JsonRequestBehavior.AllowGet);
        
                    }
                }
    // And You Should Place  "dataType: "json", " in AJAX
