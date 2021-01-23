    public class FloatTrait 
    {
        private float val;
        public FloatTrait(float val)
        {
            this.val = val;
        }
        public float Value{get { return this.val; }}
    
        public FloatTrait CombineWith(FloatTrait t)
        {
           return new FloatTrait((this.Value + t.Value)/2.0f);
        }
    }
