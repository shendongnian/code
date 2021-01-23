    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Data.Entity;
    using System.Linq;
    using System.Net;
    using System.Web;
    using System.Web.Mvc;
    using WINCMUTest.Models;
    namespace WINCMUTest.Controllers
    {
        public class WINCMU_HostInfoController : Controller
        {
            private WINCMUEntities db = new WINCMUEntities();
            // GET: WINCMU_HostInfo
            public ActionResult Index()
            {
                return View(db.WINCMU_HostInfo.ToList());
            }
            // GET: WINCMU_HostInfo/Details/5
            public ActionResult Details(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                WINCMU_HostInfo wINCMU_HostInfo = db.WINCMU_HostInfo.Find(id);
                if (wINCMU_HostInfo == null)
                {
                    return HttpNotFound();
                }
                return View(wINCMU_HostInfo);
            }
            // GET: WINCMU_HostInfo/Create
            public ActionResult Create()
            {
                return View();
            }
            // POST: WINCMU_HostInfo/Create
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Create([Bind(Include = "IP_address,HostName,Zone,ID")] WINCMU_HostInfo wINCMU_HostInfo)
            {
                if (ModelState.IsValid)
                {
                    db.WINCMU_HostInfo.Add(wINCMU_HostInfo);
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(wINCMU_HostInfo);
            }
            // GET: WINCMU_HostInfo/Edit/5
            public ActionResult Edit(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                WINCMU_HostInfo wINCMU_HostInfo = db.WINCMU_HostInfo.Find(id);
                if (wINCMU_HostInfo == null)
                {
                    return HttpNotFound();
                }
                return View(wINCMU_HostInfo);
            }
            // POST: WINCMU_HostInfo/Edit/5
            // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
            // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
            [HttpPost]
            [ValidateAntiForgeryToken]
            public ActionResult Edit([Bind(Include = "IP_address,HostName,Zone,ID")] WINCMU_HostInfo wINCMU_HostInfo)
            {
                if (ModelState.IsValid)
                {
                    db.Entry(wINCMU_HostInfo).State = EntityState.Modified;
                    db.SaveChanges();
                    return RedirectToAction("Index");
                }
                return View(wINCMU_HostInfo);
            }
            // GET: WINCMU_HostInfo/Delete/5
            public ActionResult Delete(int? id)
            {
                if (id == null)
                {
                    return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
                }
                WINCMU_HostInfo wINCMU_HostInfo = db.WINCMU_HostInfo.Find(id);
                if (wINCMU_HostInfo == null)
                {
                    return HttpNotFound();
                }
                return View(wINCMU_HostInfo);
            }
            // POST: WINCMU_HostInfo/Delete/5
            [HttpPost, ActionName("Delete")]
            [ValidateAntiForgeryToken]
            public ActionResult DeleteConfirmed(int id)
            {
                WINCMU_HostInfo wINCMU_HostInfo = db.WINCMU_HostInfo.Find(id);
                db.WINCMU_HostInfo.Remove(wINCMU_HostInfo);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            protected override void Dispose(bool disposing)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                base.Dispose(disposing);
            }
        }
    }
