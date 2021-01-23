    <telerik:RadTimeBar Name="timeBar1" Height="150"
                                PeriodStart="{Binding PeriodStart, Mode=TwoWay}" 
                                PeriodEnd="{Binding PeriodEnd, Mode=TwoWay}"
                                VisiblePeriodStart="{Binding VisiblePeriodStart, Mode=TwoWay}" 
                                VisiblePeriodEnd="{Binding VisiblePeriodEnd, Mode=TwoWay}"
                                SelectionStart="{Binding SelectedStartDate, Mode=TwoWay}"
                                SelectionEnd="{Binding SelectedEndDate, Mode=TwoWay}"
                                MinSelectionRange="{Binding MinSelectionRange, Mode=TwoWay}"
                                IsSnapToIntervalEnabled="True">
                <telerik:RadTimeBar.Intervals>
                    <telerik:QuarterInterval />
                    <telerik:MonthInterval />
                    <telerik:WeekInterval />
                    <telerik:DayInterval />
                    <telerik:HourInterval/>
                </telerik:RadTimeBar.Intervals>
                <telerik:RadLinearSparkline LineStroke="#FF767676" ItemsSource="{Binding ServerInfos}" XValuePath="Date" YValuePath="UniqueVisitors" />
            </telerik:RadTimeBar>
