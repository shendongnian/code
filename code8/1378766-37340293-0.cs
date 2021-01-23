     [RoutePrefix("api/subsection")]
        public class SubSectionController : ApiController
        {
            [HttpGet, Route("subsectionslist")]
            public IHttpActionResult GetSections(int sectionId)
            {
                using (var db = new StudyHubContext())
                {
                    var model = db.Section.Where(x => x.SectionId==sectionId)
                        .Include(x => x.SubSection)
                        .Select(x => x.SubSection)
                        .ToList();
                    return Json(model);
                }
            }
