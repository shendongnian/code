    <unity xmlns="http://schemas.microsoft.com/practices/2010/unity">
    <namespace name="ConsoleApplication8" />
    <assembly name="ConsoleApplication8" />
    <container name="MyContainer">
      <types>
        <type type="ConsoleApplication8.IRepositoryFactories, ConsoleApplication8"
               mapTo="ConsoleApplication8.RepositoryFactories, 
               ConsoleApplication8" />
        <type type="ConsoleApplication8.IRepositoryProvider, ConsoleApplication8"
               mapTo="ConsoleApplication8.RepositoryProvider, ConsoleApplication8"
               name="RepositoryProvider" >
          <lifetime type="singleton" />
          <constructor>
            <param name="factories">
              <dependency />
            </param>
          </constructor>
        </type>
      </types>
    </container>
