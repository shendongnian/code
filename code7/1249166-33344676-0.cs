    XElement root = XElement.Parse(@"
		<RoadPart>
			<Vehicles>
				<ConfigurationSummaryListPosition>
					<ConfigurationSummary>Test name</ConfigurationSummary>
				</ConfigurationSummaryListPosition>
			</Vehicles>
			<Vehicles>
				<ConfigurationSummaryListPosition>
					<ConfigurationSummary>Test name</ConfigurationSummary>
				</ConfigurationSummaryListPosition>
			</Vehicles>
			<Vehicles>
				<ConfigurationSummaryListPosition>
					<ConfigurationSummary>Test name</ConfigurationSummary>
				</ConfigurationSummaryListPosition>
			</Vehicles>
		</RoadPart>
	");
    XElement toAdd = XElement.Parse(@"
        <Vehicles>
            <ConfigurationSummaryListPositionTest>
                <ConfigurationSummary>Test name</ConfigurationSummary>
            </ConfigurationSummaryListPositionTest>
        </Vehicles>
    ");
    root.Elements().Skip(1).First().AddBeforeSelf(toAdd);
    
    //Alternatively
    root.Elements().Take(1).Last().AddAfterSelf(toAdd);
