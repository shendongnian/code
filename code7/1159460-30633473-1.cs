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
    
    /* Get list of DepNombre to exclude */
    var badDepts=db.Departmento
      .Where(d=>list2.Any(l2=>l2.DepNombre==d.DepNombre))
      .Select(d=>d.DepNombre);
    /* Exclude them */
    var goodDepts=list2.Where(l=>!badDepts.Any(bd=>bd==l.DepNombre));
    /* Add to database */
    db.Departmento.AddRange(goodDepts);
    /* Save */
    db.SaveChanges();
