     private bool _is_selected;
        public bool IsSelected
        {
            get { return _is_selected; }
            set
            {
                if (_is_selected != value)
                {
                    _is_selected = value;
                    UpdateProperty("IsSelected");
                    //We also need to raise the HasTripOrError property here to resume
                    //The red glow animation if there is an error.
                    HasTripOrError = !HasTripOrError;
                    HasTripOrError = !HasTripOrError;
                }
            }
        }
