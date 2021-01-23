    ViewModelFoo vmc = new ViewModelFoo();
    List<T_Trainee> trainees= new List<T_Trainee>();
    foreach (int f in foo)
    {
        T_Trainee t = new T_Trainee();
        t.email = (string)Session["Mail"];
        t.phone = (string)Session["Phone"];
        trainees.Add(t);
    }
    vmc.trainees = trainees;
    //code to get the PDF     
    ViewAsPdf pdf = new ViewAsPdf("Index", vmc)
    {
       FileName = "File.pdf",
       PageSize = Rotativa.Options.Size.A4,
       PageMargins = { Left = 0, Right = 0 }
    };
