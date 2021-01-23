    public class CyclePart : ContentPart<CyclePartRecord> {
        public DateTime Start {
            get { return Record.Start; }
            set { Record.Start = value; }
        }
    }
