         public ActionResult FillSegment(int siteid)
         {
            SegmentHelper segmenthelper = new SegmentHelper();      
            return Json(segmenthelper.FillSegment(siteid), JsonRequestBehavior.AllowGet);
         }
