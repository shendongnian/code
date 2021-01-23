    foreach (CharacterControl charControl in flow1.Controls) {
        foreach(Control control in charControl.Controls){
            //do something with control
            //cast Control to the correct control type by using its Name property whenever necessary
            //collect all the Text/value in the control here!, save it afterwards!
        }
    }
