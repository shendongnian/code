    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "InspekcijskoTijeloId,ProizvodId,DatumInspekcijskeKontrole,Rezultat,ProizvodSiguran,InspekcijskaKontrolaId")] InspekcijskaKontrola inspekcijskaKontrola)
    {
      if (ModelState.IsValid)
      {           
        if(inspekcijskaKontrola.chkTest == true)
        {
           inspekcijskaKontrola.responseText = "product is safe";
        }
        else 
        {
           inspekcijskaKontrola.responseText = "product is not safe";
        }
      }
    }
    public class inspekcijskaKontrola
    {
       public bool chkTest { get; set; }
       public string responseText { get; set; }
    }
