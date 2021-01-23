    Replace foreach statement block like below:
         Doctor existing = db.Doctors.Find(doc.RVH_ID_);
        if (existing != null)
        {            
                    existing.AdmPriv = doc.AdmPriv;
                    existing.QCPR = doc.QCPR;
                    existing.Keane = doc.Keane;
                    existing.Orsos = doc.Orsos;
                    existing.Soft = doc.Soft;
                    existing.C3M = doc.C3M;
        }
        }
