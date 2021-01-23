    public partial class MyEntities : ObjectContext
    {
        /// <summary>
        /// Persists all updates to the data source with the specified System.Data.Objects.SaveOptions.
        /// </summary>
        /// <param name="saveOptions">A System.Data.Objects.SaveOptions value that determines the behavior of the operation.</param>
        /// <returns>The number of objects in an System.Data.EntityState.Added, System.Data.EntityState.Modified, or 
        /// System.Data.EntityState.Deleted state when System.Data.Objects.ObjectContext.SaveChanges() was called.</returns>
        public override int SaveChanges(SaveOptions saveOptions)
        {
            List<Itinerary> itineraryLocations = ItineraryAddedDeletedMonitor.GetItineraryLocations(this);
            AlertManager.ObjectContextSavingChanges(this, null);
            int changes = base.SaveChanges(saveOptions);
            if (ItineraryAddedDeletedMonitor.ProcessItineraryLocations(this, itineraryLocations))
            {
                // new rows have been added
                base.SaveChanges(saveOptions);
            }
            return changes;
        }
    }
