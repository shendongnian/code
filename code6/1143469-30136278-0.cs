    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;
    using Biblioteca.Models;
    using CrystalDecisions.CrystalReports.Engine;
    namespace Biblioteca.Controllers
    {
        public class HomeController : Controller
    {
        private BibliotecaDatabase db = new BibliotecaDatabase();
        public ActionResult Index()
        {
            var totalesviewmodel = new TotalesViewModel();
            totalesviewmodel.MontoCopias = db.AlumnosList.Sum(o => o.Copias);
            totalesviewmodel.MontoImpresiones = db.AlumnosList.Sum(o => o.Impresiones);
            totalesviewmodel.DineroDeposito = db.AlumnosList.Sum(o => o.Deposito);
            totalesviewmodel.DineroSap = db.AlumnosList.Sum(o => o.Sap);
            totalesviewmodel.MontoCopiasMaestro = db.MaestrosList.Sum(o => o.Copias);
            totalesviewmodel.MontoImpresionesMaestro = db.MaestrosList.Sum(o => o.Impresiones);
            return View(totalesviewmodel);
        }
        public ActionResult Reports()
        {
            List<Alumno> allDatos = new List<Alumno>();
            using (BibliotecaEntities dc = new BibliotecaEntities())
            {
                allDatos = dc.Alumnos.ToList();
            }
            return View(allDatos);
        }
        public ActionResult ExportReport()
        {
            List<Alumno> allDatos = new List<Alumno>();
            using (BibliotecaEntities dc = new BibliotecaEntities())
            {
                allDatos = dc.Alumnos.ToList();
            
            ReportDocument rd = new ReportDocument();
            rd.Load(Path.Combine(Server.MapPath("~/Reports"), "rpt_datos.rpt"));
            rd.SetDataSource(allDatos);
            Response.Buffer = false;
            Response.ClearContent();
            Response.ClearHeaders();
            try
            {
                Stream stream = rd.ExportToStream(CrystalDecisions.Shared.ExportFormatType.PortableDocFormat);
                stream.Seek(0, SeekOrigin.Begin);
                return File(stream, "application/pdf", "DatoList.pdf");
            }
            catch (Exception ex)
            {
                throw;
            }
        }
        public ActionResult Contact ()
        {
            ViewBag.Message = "Your contact page.";
            return View();
        }
    }
      }
      }
