    var list=new List<Departamento>();
    /* Get from Excel */
    while ((line = rdr.ReadLine()) != null)
    {
        ....
        depto = new Departamento();
        depto.DepNombre = departamento;
        depto.Pais = pais;
        depto.DepCreadoEn = DateTime.Now;
        list.Add(depto);
    }
    
    /* Group By */
    var list2=list.GroupBy(x=>x.DepNombre,(key,g)=>g.OrderBy(e=>e.DepCreadoEn).First());
    
    db.SaveChanges();
