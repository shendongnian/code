    <TableView>
        <TableView.Root>
	        <TableSection Title="Login">    	
    		    <EntryCell Text="{Binding Phone}" />
                <EntryCell Text="{Binding Code}" />
                <TextCell Text="LOGIN" Command="{Binding Login}"/>
    		</TableSection>
    	</TableView.Root>
    </TableView>
