    // xmal code    
    <ListView x:Name="listView">
        <ListView.View>
            <GridView>
                <GridViewColumn Header="FieldId" DisplayMemberBinding="{Binding FieldId}"/>
                <GridViewColumn Header="FieldLength" DisplayMemberBinding="{Binding FieldLength}"/>
             </GridView>
        </ListView.View>
    </ListView>
    
        // define your custom listview item class
        public class MyFieldListViewItem
        {
            public string FieldId { get; set; }
        
            public string FieldLength { get; set; }
        }
        
        // when adding the item
        for (intDisplayCnt = 0; intDisplayCnt < intFieldLengths.Length; intDisplayCnt++)
        {
            var fieldId = "Field" + (intDisplayCnt + 1);
            var fieldLen = intFieldLengths[intDisplayCnt].ToString();
            lvwFieldInfo.Items.Add(new MyFieldListViewItem { FieldId = fieldId, FieldLength = fieldLen });
        }
