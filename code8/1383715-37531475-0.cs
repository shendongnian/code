            //// MODEL            
            public class HtmlNode
            {
              public List<HtmlNode> Children{get; set;}
            }
        
            //// VIEW-MODEL
            public class HtmlTreeViewModel
            {
              public HtmlNode RootNode {get; set;}
    
              public List<HtmlNode> TreeItems{get; set;}
              ICommand ItemClickedCommand;
              public HtmlTreeViewModel()
              {
               // Get Initial Items
               TreeItems = GenerateTreeOfHtmlObjects(RootNode);
               ItemClickedCommand = new Command(ItemClickCommadFunc);
              }
    
              private List<HtmlNode> ItemClickCommadFunc(object itemClicked)
              {
                  // Fill Children for specific node
                  HtmlNode node =(itemClicked as HtmlNode);
                  node.Children = GenerateTreeOfHtmlObjects(node);
              }
              
            }
            //// VIEW
        //This is the datatemplate for each item (you can add name and other stuff)
        //should be defined in resources
        <DataTemplate x:key="NodeTemplate">
           <StackLayout ItemSource="{Binding Children}">
           </StackLayout>
        </DataTemplate>
    
        //this is the StackLayout that represent the whole tree
        <StackLayout ItemsSource="{Binding RootItem.Children}" ItemTemplate=" StaticResource NodeTemplate}"/>
