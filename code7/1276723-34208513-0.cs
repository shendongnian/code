    Debug.WriteLine("Succeed to load resource.");
                //splitting up resource into array
                Debug.WriteLine("Splitting up upper resource into string[]");
                string_array = temp_string.Split(remove_chars);
                for(int i = 0; i < word_count; i++) {
    
                    string_array[i].Trim(remove_chars);
    
                    //setting Language_Strings strings
                    if (i == 0)
                    {
                        Language_Strings.main_form_Text = string_array[i];
                    }
                    if(i == 1) 
                    {
                        Language_Strings.project_menu_item_Text = string_array[i];
                    }
    
                }
                Debug.WriteLine("Succeeded to set strings' texts");
