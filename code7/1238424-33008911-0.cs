    Imports System.ComponentModel.DataAnnotations
    Imports System.ComponentModel.DataAnnotations.Schema
    Imports System.Data.Entity
    Module Module1
        Sub Main()
        Dim sell = New Sell() With {
            .Value = 1D
        }
        Dim financ = New Financial() With {
            .[Date] = DateTime.Now,
            .Sell = sell
        }
        Using ctx = New XContext()
            ctx.Financials.Add(financ)
            ctx.FinancialSells.Add(New FinancialSell With {.Financial = financ, .Sell = sell})
            ctx.SaveChanges()
            Console.WriteLine("Ok Success!")
        End Using
    End Sub
    End Module
    Partial Public Class XContext
    Inherits DbContext
    Public Sub New()
        'Recreates your database when it changes.
        Database.SetInitializer(Of XContext)(New DropCreateDatabaseIfModelChanges(Of XContext)())
        'MyBase.New("name=XContext")
    End Sub
        Public Overridable Property Financials As DbSet(Of Financial)
        Public Overridable Property Sells As DbSet(Of Sell)
        Public Overridable Property FinancialSells As DbSet(Of FinancialSell)
        Protected Overrides Sub OnModelCreating(modelBuilder As DbModelBuilder)
        modelBuilder.Entity(Of FinancialSell)().HasRequired(Function(x) x.Sell).WithMany().WillCascadeOnDelete(False)
    End Sub
    End Class
    <Table("Sell")>
    Partial Public Class Sell
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")>
        Public Sub New()
            Financial = New HashSet(Of Financial)()
        End Sub
        <Key, DatabaseGenerated(DatabaseGeneratedOption.Identity), ScaffoldColumn(False)>
        Public Property ID As Integer
        Public Property Value As Decimal
        <System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")>
        Public Overridable Property Financial As ICollection(Of Financial)
    End Class
    <Table("Financial")>
    Partial Public Class Financial
        <Key, Column(Order:=0), DatabaseGenerated(DatabaseGeneratedOption.Identity), ScaffoldColumn(False)>
        Public Property ID As Integer
        Public Property [Date] As DateTime
        <Column(Order:=1), ForeignKey("Sell")>
        Public Property SellID As Integer
        'Navigation Properties
        Public Overridable Property Sell As Sell
    End Class
    Partial Public Class FinancialSell
        <Key, Column(Order:=0), ForeignKey("Financial")>
        Public Property FinancialID As Integer
        <Key, Column(Order:=1), ForeignKey("Sell")>
        Public Property SellID As Integer
        'Navigation Properties
        Public Overridable Property Sell As Sell
        Public Overridable Property Financial As Financial
    End Class
