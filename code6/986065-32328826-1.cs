     <ContentPage xmlns:local="clr-namespace:Behaviors;assembly=Behaviors" ... >
     <Entry Placeholder="Enter some text">
         <Entry.Behaviors>
            <local:TextValidationBehavior IsValid={Binding IsEntryValid} />
       </Entry.Behaviors>
     </Entry>
     </ContentPage>
