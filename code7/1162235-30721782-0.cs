    if (es is Student)
    {
       Debug.Log((es as Student).param1); 
    }
    else if (es is Teacher)
    {
       Debug.log((es as Teacher).param2);
    }
    else
    {
        //some other entity
    }
