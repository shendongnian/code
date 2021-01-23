    <sitecore>
        <model>
          <elements>
            <element interface="Namespace.IPlaces, Dllname" implementation="Namespace.Places, Dllname" />
            <element interface="Namespace.IPlace , Dllname" implementation="Namespace.Place, Dllname" />
            <element interface="Namespace.ICoordinate, Dllname" implementation="Namespace.Coordinate , Dllname" />
            
          </elements>
          <entities>
            <contact>
              <facets>
                <facet name="name form XML config" contract="Namespace.IPlaces, Dllname" />
              </facets>
            </contact>
          </entities>
        </model>
      </sitecore>
