    Public Class Waitress
        Inherits Employee
        Public Sub New
           MyBase.GetsTips = True
           ' do other stuff including class specific params from wherever
           MyBase.MinSalary = minsalary from whereever you store it
           ' or maybe.....
           MyBase.MaxSalary = SalaryClass.GetMax(enumEmp.Waitress)
        End Sub
    End Class
