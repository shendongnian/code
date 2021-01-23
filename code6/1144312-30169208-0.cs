        Magnus(MM8) - Given beautiful solution for this.
        https://social.msdn.microsoft.com/profile/magnus%20(mm8)/?ws=usercard-mini 
        
        **Just set the TargetObject property of the actions to TooltipBrd and your code will work:**
        
               public void LoadData() {
                  //VisualState vs = new VisualState();
                  //vs.SetValue(FrameworkElement.NameProperty, YourStateName);
            
                  Button Button1 = new Button() { Cursor = Cursors.Hand, Content = "Press Me!" };
                  stackPanel5.Children.Add(Button1);
            
                  Border TooltipBrd = new Border() {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(10, 10, 10, 10),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Visibility = Visibility.Collapsed
                  };
            
                  TextBlock txtB1 = new TextBlock() { Text = "Lakshman", Margin = new Thickness(0, 100, 0, 0) };
                  TooltipBrd.Child = txtB1;
            
                  stackPanel5.Children.Add(TooltipBrd);
            
                  System.Windows.Interactivity.EventTrigger trigger1 = new System.Windows.Interactivity.EventTrigger();
                  trigger1.EventName = "MouseEnter";
            
                  ChangePropertyAction action1 = new ChangePropertyAction();
                  action1.**TargetObject** = TooltipBrd;
                  action1.PropertyName = "Visibility";
                  action1.Value = Visibility.Visible;
            
                  trigger1.Actions.Add(action1);
                  trigger1.Attach(Button1);
            
                  System.Windows.Interactivity.EventTrigger trigger2 = new System.Windows.Interactivity.EventTrigger();
                  trigger2.EventName = "MouseLeave";
            
                  ChangePropertyAction action2 = new ChangePropertyAction();
                  action2.**TargetObject** = TooltipBrd;
                  action2.PropertyName = "Visibility";
                  action2.Value = Visibility.Collapsed;
            
                  trigger2.Actions.Add(action2);
                  trigger2.Attach(Button1);
                }
        
        **If you set the TargetName property you need to call the RegisterName method on the StackPanel:**
        int i = 0;
    public void LoadData()
            {
                ++i;
                //VisualState vs = new VisualState();
                //vs.SetValue(FrameworkElement.NameProperty, YourStateName);
    
                Button Button1 = new Button() { Cursor = Cursors.Hand, Content = "Press Me!", Height = 150, Width=150 };
                stackPanel5.Children.Add(Button1);
    
                Border TooltipBrd = new Border()
                {
                    BorderBrush = Brushes.Black,
                    BorderThickness = new Thickness(10, 10, 10, 10),
                    HorizontalAlignment = HorizontalAlignment.Center,
                    VerticalAlignment = VerticalAlignment.Center,
                    Visibility = Visibility.Collapsed
                };
    
                TextBlock txtB1 = new TextBlock() { Text = "Lakshman", Margin = new Thickness(0, 100, 0, 0) };
                TooltipBrd.Child = txtB1;
    
                stackPanel5.Children.Add(TooltipBrd);
    
                System.Windows.Interactivity.EventTrigger trigger1 = new System.Windows.Interactivity.EventTrigger();
                trigger1.EventName = "MouseEnter";
    
                ChangePropertyAction action1 = new ChangePropertyAction();
                //action1.TargetObject = TooltipBrd;
                action1.TargetName = "TooltipBrd"+i;
                action1.PropertyName = "Visibility";
                action1.Value = Visibility.Visible;
    
                trigger1.Actions.Add(action1);
                trigger1.Attach(Button1);
    
                System.Windows.Interactivity.EventTrigger trigger2 = new System.Windows.Interactivity.EventTrigger();
                trigger2.EventName = "MouseLeave";
    
                ChangePropertyAction action2 = new ChangePropertyAction();
                action2.TargetName = "TooltipBrd"+i;
                //action2.TargetObject = TooltipBrd;
                action2.PropertyName = "Visibility";
                action2.Value = Visibility.Collapsed;
    
                trigger2.Actions.Add(action2);
                trigger2.Attach(Button1);
                **stackPanel5.RegisterName("TooltipBrd"+i, TooltipBrd);**
            }    
        When you are creating controls dynamically, you have to call the RegisterName method for the runtime or you to be able to find them using this name.
