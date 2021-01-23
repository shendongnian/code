    Protected Sub Page_Load(ByVal sender As Object, ByVal e As EventArgs) Handles Me.Load
    
            Dim props As OffAmazonPaymentsServicePropertyCollection = OffAmazonPaymentsServicePropertyCollection.getInstance()
            Dim client As New OffAmazonPaymentsServiceClient(props)
            Dim result as GetOrderReferenceDetailsResponse = GetAmzOrderRef(client, props, "oref", "token")
    
    End Sub
    Private Shared Function GetAmzOrderRef(service As IOffAmazonPaymentsService, props As OffAmazonPaymentsServicePropertyCollection, amazonOrderReferenceId As String, addressConsentToken As String) As GetOrderReferenceDetailsResponse
    
            Dim request as New GetOrderReferenceDetailsRequest()
            With request
                .SellerId = props.MerchantID
                .AmazonOrderReferenceId = amazonOrderReferenceId
                .AddressConsentToken = addressConsentToken
            End With
            Return service.GetOrderReferenceDetails(request)
    
    End Function
