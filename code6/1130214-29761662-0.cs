    [HttpPost]
    public class ActionResult Save(MyViewModel vmData)
    {
        FirstModel firstModel = new FirstModel();
        SecondModel secondModel = new SecondModel();
        firstModel.MyDetails = vmData.MyDetails;
        secondModel.MyDetails = vmData.MyDetails2;
        secondModel.FirstModel = firstModel;
        db.SecondModel.Add(secondModel);
        db.SaveChanges();
    }
