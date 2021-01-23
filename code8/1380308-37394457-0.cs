    public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Consulta consulta = db.Consultas.Find(id);
            if (consulta == null)
            {
                return HttpNotFound();
            }
            return View(consulta);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ConsultaID,Usuario,FechaEntrada,Hardware,HardwareY,Software,SoftwareY,MaterialConsultaAlta,MaterialConsultaAltaY,InstalTelefonoInternet,InstalTelefonoInternetY,AlquilerOficina,AlquilerOficinaY,MobiliarioOficina,MobiliarioOficinaY,ImagenProfesional,ImagenProfesionalY,GastosEstablVarios,GastosEstablVariosY,MaterialConsultaRenov,MaterialConsultaRenovY,HardwareRenov,HardwareRenovY,SoftwareRenov,SoftwareRenovY,Afiliaciones,AfiliacionesY,Proteccion,ProteccionY,DominioInternet,DominioInternetY,MaterialFungible,MaterialFungibleY,Formacion,FormacionY, Publicidad, PublicidadY,Imprevistos,ImprevistosY,PRL,PRLY,GastosAnualesVarios,GastosAnualesVariosY,AlquilerOficinaMensual,AlquilerOficinaMensualY,SeguridadSocial,SeguridadSocialY,SeguroMedico,SeguroMedicoY,LuzCalefaccion,LuzCalefaccionY,GestoriaLitigios,GestoriaLitigiosY,AsesoriaAveriasInf,AsesoriaAveriasInfY,AlojamientoWeb,AlojamientoWebY,TelefonoInternetMensual,TelefonoInternetMensualY,GastosMensualesVarios,GastosMensualesVariosY,DiasVacaciones,DiasFestivos,DiasImprevistos,DiasTrabajoSemana,DiasFormacion,DiasGestiones,HorasTraduccion,TrabajoProductivo,Rendimiento,PrecioPalabra,PagasAnual,IRPF,SueldoMensual,NumeroPagas,IRPFdc,SueldoMensualdt,NumeroPagasdt,TarifaCobro,RendimientoDT")] Consulta consulta)
        {
            if (ModelState.IsValid)
            {
                db.Entry(consulta).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(consulta);
        }
