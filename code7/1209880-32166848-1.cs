    Imports System.ServiceModel
    Imports System.ServiceModel.Web
    
    <ServiceContract()>
    Public Interface IService
        <OperationContract>
        <WebGet(UriTemplate:="/method/{parameter}")>
        Function getData(ByVal parameter As String) As String
    End Interface
