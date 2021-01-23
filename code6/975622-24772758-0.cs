         var queryDepartemen = (from so in StrukturOrganisasis.AsParallel()
                        join dp in Departemens on so.ID equals dp.ID
                        orderby dp.ID
                        select new{dp.ID, so.Inisial, so.Nama}).ToList();
      foreach(var departemen in queryDepartemen.AsParallel()){
                        var queryMayor = (from my in Mayors
                        where my.DepartemenID == departemen.ID && my.StrataID == 2
                        select my.ID).ToList();
    var queryMhs = (from ms in MahasiswaSarjanas.AsParallel()
                    where queryMayor.Contains(ms.MayorID) &&
                        (
                            from sm in StatusMahasiswas
                            where
                                (
                                    from ts in TahunSemesters
                                    where ts.TahunAwal == 2013
                                    select ts.ID
                                )
                            .Contains(sm.TahunSemesterID)
                            select sm.NIM
                        )
                    .Contains(ms.NIM)
                    select ms.NIM).ToList();
