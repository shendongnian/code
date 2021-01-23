    public class MyComboBoxBehavior : Behavior<GridViewBase>
    {
        protected override void OnAttached()
        {
            base.OnAttached();
            GridControl gridControl = AssociatedObject.Grid;
            // Logic for combobox handling goes here
        }
    }
    <dxg:GridControl>
            <dxg:GridControl.View>
                <dxg:TableView>
                    <i:Interaction.Behaviors>
                        <local:MyComboBoxBehavior/>
                    </i:Interaction.Behaviors>
                </dxg:TableView>
            </dxg:GridControl.View>
        </dxg:GridControl>
