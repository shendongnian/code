            foreach (var item in Globals.Items)
    		{
    			var text = Instantiate(itemText) as Text;
    			var button = Instantiate(itemButton) as Button;
    			button.GetComponentInChildren<Text>().text = "Delete";
    			textsList.Add(text); //save Text element to list to have possibility of destroying Text gameObjects
    			buttonsList.Add(button);//save Button element to list to have possibility of destroying Button gameObjects
    			text.gameObject.SetActive(true);
    			button.gameObject.SetActive(true);
    
                // this line:
    			button.onClick += delegate {Destroy(text.gameObject); Destroy(button.gameObject);};
    
    			//(...) Setting GUI items position here
    		}
