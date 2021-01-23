    public class tbl_vessels {
        [Key]
        public int vessel_idx { get; set; }
        
        //Navigation property
        public IList<the_vessel_spec>  the_vessel_specs { get; set; }
    }
    
    public class the_vessel_spec {
        [Key]
        public int vessel_spec_idx { get; set; }
        
        [ForeignKey("vessel_parent")]
        public int vessel_parent_id { get; set; }
        
        //Navigation property
        public tbl_vessels vessel_parent { get; set; }
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(FullVesselViewModel model)
    {
        var the_vessel = new tbl_vessels
        {
            //vessel_name = model.vessel_name,
            //vessel_imono = model.vessel_imono,
            
            the_vessel_specs = new List {
                new tbl_vessel_spec
                {
                    //vessel_bhp = model.vessel_bhp
                    //parent_id = model.vessel_idx
                }
            }
        };
        
        using (var context = new seabrokersEntities())
        {
            context.tbl_vessels.Add(the_vessel);
            context.SaveChanges();
        }
         return View("Index");
    }
