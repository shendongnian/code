    public ActionResult ShowPhoto(int id)
    {
        InspectionPhoto image = db.InspectionPhotoes.Find(id);
        byte[] result = image.ImageBytes;
        return File(result, "image/png");
    }
