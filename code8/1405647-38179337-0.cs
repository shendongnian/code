    public class FingerprintStatus{
            public string UserId { get; set; }
            public int StatusId { get; set; }
            public int FingerprintId { get; set; }
            public bool IsDeleted { get; set; }
    
    }
        [HttpPut]
                public JsonResult UpdateFingerprintStatus(FingerprintStatus model)
                {
                    var response = _driver.UpdateFingerprintGrantById(model.UserId, model.FingerprintId, model.IsDeleted, model.StatusId);
                    return Json(response.Note);
                }
