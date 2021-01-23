    Imports Hangfire
    Imports System.Reflection
    Public Class JobActivationContainer
        Inherits JobActivator
        Private Property ParameterMap As Dictionary(Of Type, [Delegate])
        Private Function CompareParameterToMap(p As ParameterInfo) As Boolean
            Dim result = ParameterMap.ContainsKey(p.ParameterType)
            Return result
        End Function
    
        Public Overrides Function ActivateJob(jobType As Type) As Object
            Dim candidateCtor As Reflection.ConstructorInfo = Nothing
            'Loop through ctor's and find the most specific ctor where map has all types.
            jobType.
                GetConstructors.
                ToList.
                ForEach(
                    Sub(i)
                        If i.GetParameters.ToList.
                            TrueForAll(AddressOf CompareParameterToMap) Then
                                If candidateCtor Is Nothing Then candidateCtor = i
                                If i IsNot candidateCtor AndAlso i.GetParameters.Count > candidateCtor.GetParameters.Count Then candidateCtor = i
                        End If
                    End Sub
                )
    
                If candidateCtor Is Nothing Then
                    'If the ctor is null, use default activator.
                    Return MyBase.ActivateJob(jobType)
                Else
                    'Create a list of the parameters in order and activate
                    Dim ctorParameters As New List(Of Object)
                    candidateCtor.GetParameters.ToList.ForEach(Sub(i)       ctorParameters.Add(ParameterMap(i.ParameterType).DynamicInvoke()))
                Return Activator.CreateInstance(jobType, ctorParameters.ToArray)
            End If
        End Function
        Public Sub RegisterDependency(Of T)(factory As Func(Of T))
            If Not ParameterMap.ContainsKey(GetType(T)) Then    ParameterMap.Add(GetType(T), factory)
        End Sub
    
        Public Sub New()
            ParameterMap = New Dictionary(Of Type, [Delegate])
        End Sub
    End Class
