            string XmlData = "<Parent>";
            var stuclass = frm.GetValues("stuclass");
            var InstituteId = frm.GetValues("Institute");
            var obtmark = frm.GetValues("obtmark");
            var totalmark = frm.GetValues("totalmark");
            var per = frm.GetValues("per");
           
            int count = stuclass.Count();
            for (int i = 0; i < count; i++)
            {
                XmlData += "<child><stuclass>" + stuclass[i] + "</stuclass>"
                                + "<InstituteId>" + InstituteId[i] + "</InstituteId>"
                                 + "<obtmark>" + obtmark[i] + "</obtmark>"
                                 + "<totalmark>" + totalmark[i] + "</totalmark>"
                                 + "<per>" + per[i] + "</per>"
                                   + "</child>";
            }
            XmlData += "</Parent>";
            model.XmlData = XmlData;
            var res = studal.Insertdtl(model);
            return View();
        }
