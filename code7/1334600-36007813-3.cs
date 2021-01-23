    class YourListAdapter {
    
    OnCheckBoxClickListener mListener;
    
        public override View GetView(int position, View convertView, ViewGroup parent) {   
            //code for view generation
            var checkbox = convertView.FindViewById<Checkbox>(Resource.Id.YourCheckbox);
            checkbox.Selected += (sender, args) => {
                mListener.OnCheckboxClicked();
            }
        }
    }
