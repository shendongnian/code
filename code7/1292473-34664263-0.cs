    Public Class AuctionsDataContext
        Inherits DbContext
    
        Public Property Auctions As DbSet(Of Auction)
        Public Property Bids As DbSet(Of Bid)
    
        Shared Sub New()
            Database.SetInitializer(New DropCreateDatabaseIfModelChanges(Of AuctionsDataContext))
        End Sub
    
    End Class
