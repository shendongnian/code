    public int CreateVessel(Vessel newVessel)
        {
            using (BoatContext dbContext = new BoatContext())
            {
                newVessel.VesselId = new Vessel().VesselId;
                //newVessel.Attachment = null
                // OR
                //Attachment attach = new Attachment();
                //newVessel.Attachement = attach;
 
                dbContext.Vessels.Add(newVessel);                   
                dbContext.SaveChanges();
                //return new vessel id
                return Convert.ToInt32(newVessel.VesselId);
            }
        }
