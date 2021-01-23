    <edmx:StorageModels>
    	<Schema>
    		<EntityContainer>
    			<EntitySet Name="books" EntityType="Self.books" store:Type="Tables" store:Schema="public">
    				<DefiningQuery>SELECT "books"."name", (("books"."price")::double precision)::numeric FROM "public"."books" AS "books"</DefiningQuery>
    			</EntitySet>
    		</EntityContainer>
    	</Schema>
    </edmx:StorageModels>
