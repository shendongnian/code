    <MenuItem Name="miCommunityHealthIssues" Margin="3,3,3,6" Click="miCommunityHealthIssues_Click" DataContext="{Binding RelativeSource={RelativeSource Mode=FindAncestor, AncestorType=UserControl}}" Style="{StaticResource ShowMenuItemFilterStyle}">
        <MenuItem.ContextMenu>
            <!-- no datacontext definition necessary -->
            <ContextMenu> 
                <MenuItem Name="miShowComhealthIssues" IsCheckable="True" IsChecked="{Binding IncludeCommunityRecords}" Checked="MenuItem_Checked" Unchecked="MenuItem_Unchecked"/>
                <MenuItem Name="miShowSupComhealthIssues" IsCheckable="True" IsChecked="{Binding IncludeSuppressedCommunityRecords}" Checked="miShowSupComhealthIssues_Checked" Unchecked="miShowSupComhealthIssues_Unchecked"/>
            </ContextMenu>
        </MenuItem.ContextMenu>
    </MenuItem>
