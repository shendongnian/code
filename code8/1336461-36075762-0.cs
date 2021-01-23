        public void OnTimeSet (TimePicker view, int hourOfDay, int minute)
    {   
    if(pickerID == TIME_PICKER_FROM){
        UpdateDisplayEnd (hourOfDay, minute);}
    else if(pickerID == TIME_PICKER_TO)
    {
        UpdateDisplayStart (hourOfDay, minute);
    }
    }
