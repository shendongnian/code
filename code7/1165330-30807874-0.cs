    public ActionResult MedicosList(String order,String Search_Data)
    {
        var medicoEntity = new MedsEntities();
        System.Diagnostics.Debug.WriteLine("NO HAY D:");
        var lolo = medicoEntity.Medico.Where(stu =>
                       stu.NOMBRE.Contains(Search_Data.ToUpper()) ||
                       stu.TIPO.ToUpper().Contains(Search_Data.ToUpper())
                   ).ToList();
        System.Diagnostics.Debug.WriteLine("SI HAY :D");
        return View(lolo);
    }
