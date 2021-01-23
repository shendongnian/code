    public class InvoiceReceiveShipmentVM
    {
        public override bool Equals(object obj)
        {
            if (obj is InvoiceReceiveShipmentVM == false) return false;
            var invoice = (InvoiceReceiveShipmentVM)obj;
            return invoice.InvoiceNumber == InvoiceNumber
                && invoice.InvoiceType == InvoiceType
                && invoice.InvoiceStatus == InvoiceStatus
                && invoice.Lines == Lines
                && invoice.Total == Total
                && invoice.Carrier == Carrier;
        }
        public override int GetHashCode()
        {
            return InvoiceNumber.GetHashCode()
                ^ InvoiceType.GetHashCode()
                ^ InvoiceStatus.GetHashCode()
                ^ Lines.GetHashCode()
                ^ Total.GetHashCode()
                ^ Carrier.GetHashCode();
        }
    }
