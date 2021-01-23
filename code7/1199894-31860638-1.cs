    using System.Threading.Tasks;
    
    public void MainMethod() {
        // Parallel.ForEach will automagically run the "right" number of threads in parallel
        Parallel.ForEach(shipments, shipment => ProcessShipment(shipment));
    
        // do something when all shipments have been processed
    }
    
    public void ProcessShipment(Shipment shipment) { ... }
