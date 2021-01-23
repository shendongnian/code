    <UserControl x:Class="WPFAddGridViewColumnDynamicHelpAttempt.BindingTest"
             xmlns="http://schemas.microsoft.com/winfx/2006/xaml/presentation"
             xmlns:x="http://schemas.microsoft.com/winfx/2006/xaml"
             xmlns:mc="http://schemas.openxmlformats.org/markup-compatibility/2006" 
             xmlns:d="http://schemas.microsoft.com/expression/blend/2008"
             xmlns:clr="clr-namespace:System;assembly=mscorlib"
             xmlns:wpfAddGridViewColumnDynamicHelpAttempt="clr-namespace:WPFAddGridViewColumnDynamicHelpAttempt"
             mc:Ignorable="d" 
             d:DesignHeight="300" d:DesignWidth="300" x:Name="This">
    <UserControl.DataContext>
        <wpfAddGridViewColumnDynamicHelpAttempt:UpdatedViewModel/>
    </UserControl.DataContext>
    <ListView x:Name="OuterListView" ItemsSource="{Binding Data}">
        <ListView.ItemContainerStyle>
            <Style TargetType="ListViewItem">
                <Setter Property="ContentTemplate">
                    <Setter.Value>
                        <DataTemplate>
                            <ListView x:Name="InnerListView" ItemsSource="{Binding MappedObjects}">
                                <ListView.View>
                                    <GridView wpfAddGridViewColumnDynamicHelpAttempt:GridViewColumns.HeaderTextMember="HeaderText"
                                              wpfAddGridViewColumnDynamicHelpAttempt:GridViewColumns.DisplayMemberMember="DisplayMember"
                                              wpfAddGridViewColumnDynamicHelpAttempt:GridViewColumns.ColumnTemplateKey="ColumnTemplateTemplateKey"
                                              wpfAddGridViewColumnDynamicHelpAttempt:GridViewColumns.ColumnsSource="{Binding ElementName=This, Path=DataContext.ColumnHeaders}">
                                    </GridView>
                                </ListView.View>
                            </ListView>
                        </DataTemplate>
                    </Setter.Value>
                </Setter>
            </Style>
        </ListView.ItemContainerStyle>
    </ListView></UserControl>
